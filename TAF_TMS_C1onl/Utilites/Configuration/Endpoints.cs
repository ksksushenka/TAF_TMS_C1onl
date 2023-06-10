namespace TAF_TMS_C1onl.Utilites.Configuration;

public class Endpoints
{
    public static readonly string GET_PROJECT = "index.php?/api/v2/get_project/{project_id}";

    public static readonly string GET_CASE = "index.php?/api/v2/get_case/{case_id}";
    public static readonly string ADD_CASE = "index.php?/api/v2/add_case/{section_id}";
    public static readonly string UPDATE_CASE = "index.php?/api/v2/update_case/{case_id}";
    public static readonly string DELETE_CASE = "index.php?/api/v2/delete_case/{case_id}";

    public static readonly string GET_MILESTONE = "index.php?/api/v2/get_milestone/{milestone_id}";
    public static readonly string ADD_MILESTONE = "index.php?/api/v2/add_milestone/{project_id}";
    public static readonly string UPDATE_MILESTONE = "index.php?/api/v2/update_milestone/{milestone_id}";
    public static readonly string DELETE_MILESTONE = "index.php?/api/v2/delete_milestone/{milestone_id}";
}