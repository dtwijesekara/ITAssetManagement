using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using ITAssetManagement.BusinessLogic;

namespace ITAssetManagement.DataAccess
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["ITAssetManagementDB"]?.ConnectionString
                ?? throw new InvalidOperationException(
                    "Connection string 'ITAssetManagementDB' not found in App.config.");
        }

        public string AuthenticateUser(string username, string passwordHash)
        {
            string query = @"SELECT Role FROM dbo.tbl_Users
                              WHERE Username = @Username AND PasswordHash = @PasswordHash;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? result.ToString() : null;
                }
                catch (SqlException sqlEx)
                {
                    throw new DataAccessException($"Authentication failed. DB Error #{sqlEx.Number}: {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException($"Unexpected login error: {ex.Message}", ex);
                }
            }
        }

        public DataTable GetAssets()
        {
            DataTable dt = new DataTable();
            string query = @"
                SELECT
                    a.AssetID, a.AssetType, a.MakeModel, a.OS_Version,
                    a.IPAddress, a.MACAddress, a.HasEncryptedDisk, a.IsCorpManaged,
                    a.HasDefaultCreds, a.HasFirewallEnabled, a.FirmwareVersion,
                    ISNULL(e.FullName,   'Unassigned') AS AssignedTo,
                    ISNULL(e.Department, 'N/A')        AS Department
                FROM dbo.tbl_Assets a
                LEFT JOIN dbo.tbl_Employees e ON a.AssignedTo_EmpID = e.EmpID
                ORDER BY a.AssetID ASC;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (SqlException sqlEx)
                {
                    throw new DataAccessException($"Error fetching assets. DB Error #{sqlEx.Number}: {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException($"Unexpected error fetching assets: {ex.Message}", ex);
                }
            }

            return dt;
        }

        public int AddAsset(Asset asset)
        {
            if (asset == null) throw new ArgumentNullException(nameof(asset));

            string query = @"
                INSERT INTO dbo.tbl_Assets
                    (AssetType, MakeModel, OS_Version, AssignedTo_EmpID,
                     IPAddress, MACAddress, HasEncryptedDisk, IsCorpManaged,
                     HasDefaultCreds, HasFirewallEnabled, FirmwareVersion)
                VALUES
                    (@AssetType, @MakeModel, @OS_Version, @AssignedTo_EmpID,
                     @IPAddress, @MACAddress, @HasEncryptedDisk, @IsCorpManaged,
                     @HasDefaultCreds, @HasFirewallEnabled, @FirmwareVersion);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AssetType",  asset.AssetType);
                cmd.Parameters.AddWithValue("@MakeModel",  asset.MakeModel);
                cmd.Parameters.AddWithValue("@OS_Version", asset.OS_Version);
                cmd.Parameters.AddWithValue("@IPAddress",  asset.IPAddress);
                cmd.Parameters.AddWithValue("@MACAddress", asset.MACAddress);
                cmd.Parameters.AddWithValue("@AssignedTo_EmpID",
                    asset.AssignedTo.HasValue ? (object)asset.AssignedTo.Value : DBNull.Value);

                if (asset is Laptop laptop)
                {
                    cmd.Parameters.AddWithValue("@HasEncryptedDisk", laptop.HasEncryptedDisk);
                    cmd.Parameters.AddWithValue("@IsCorpManaged",    laptop.IsCorpManaged);
                    cmd.Parameters.AddWithValue("@HasDefaultCreds",  false);
                    cmd.Parameters.AddWithValue("@HasFirewallEnabled", true);
                    cmd.Parameters.AddWithValue("@FirmwareVersion",  DBNull.Value);
                }
                else if (asset is Router router)
                {
                    cmd.Parameters.AddWithValue("@HasEncryptedDisk", false);
                    cmd.Parameters.AddWithValue("@IsCorpManaged",    false);
                    cmd.Parameters.AddWithValue("@HasDefaultCreds",  router.HasDefaultCredentials);
                    cmd.Parameters.AddWithValue("@HasFirewallEnabled", router.HasFirewallEnabled);
                    cmd.Parameters.AddWithValue("@FirmwareVersion",
                        string.IsNullOrEmpty(router.FirmwareVersion) ? (object)DBNull.Value : router.FirmwareVersion);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@HasEncryptedDisk", false);
                    cmd.Parameters.AddWithValue("@IsCorpManaged",    false);
                    cmd.Parameters.AddWithValue("@HasDefaultCreds",  false);
                    cmd.Parameters.AddWithValue("@HasFirewallEnabled", true);
                    cmd.Parameters.AddWithValue("@FirmwareVersion",  DBNull.Value);
                }

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    return (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                }
                catch (SqlException sqlEx)
                {
                    string detail = sqlEx.Number == 547
                        ? "The assigned Employee ID does not exist in the database."
                        : sqlEx.Message;
                    throw new DataAccessException($"Failed to add asset. DB Error #{sqlEx.Number}: {detail}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException($"Unexpected error adding asset: {ex.Message}", ex);
                }
            }
        }

        public void DeleteAsset(int assetId)
        {
            string query = "DELETE FROM dbo.tbl_Assets WHERE AssetID = @AssetID;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@AssetID", assetId);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException sqlEx)
                {
                    throw new DataAccessException($"Failed to delete asset. DB Error #{sqlEx.Number}: {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException($"Unexpected error deleting asset: {ex.Message}", ex);
                }
            }
        }

        public DataTable GetEmployees()
        {
            DataTable dt = new DataTable();
            string query = "SELECT EmpID, FullName, Department FROM dbo.tbl_Employees ORDER BY FullName;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                try
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
                catch (SqlException sqlEx)
                {
                    throw new DataAccessException($"Error fetching employees. DB Error #{sqlEx.Number}: {sqlEx.Message}", sqlEx);
                }
                catch (Exception ex)
                {
                    throw new DataAccessException($"Unexpected error fetching employees: {ex.Message}", ex);
                }
            }

            return dt;
        }

        public DataTable RunVulnerabilityAudit()
        {
            var auditor = new VulnerabilityAuditor(_connectionString);
            return auditor.GetVulnerableAssets();
        }

        internal string ConnectionString => _connectionString;
    }
}
