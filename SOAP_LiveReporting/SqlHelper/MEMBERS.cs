using _SqlHelper;

/// <summary>
/// Summary description for MEMBERS
/// </summary>
public sealed class MEMBERS : SqlHelper
{
    public struct SQLReturnValue
    {
        public int ValueFromSQL;
        public string MessageFromSQL;
        public string MessageFromSQL1;
    }
    public struct SqlReturnMessage
    {
        public string MessageFromSql;
    }
    public struct SQlReturnInteger
    {
        public int ValueFromSQL;
    }
    public struct SQlReturnFloat
    {
        public float ValueFromSQL;
    }
}