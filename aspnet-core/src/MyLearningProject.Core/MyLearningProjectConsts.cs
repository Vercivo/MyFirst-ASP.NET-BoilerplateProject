using MyLearningProject.Debugging;

namespace MyLearningProject;

public class MyLearningProjectConsts
{
    public const string LocalizationSourceName = "MyLearningProject";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "58c284ccad4647b2b7cb75973b8ca683";
}
