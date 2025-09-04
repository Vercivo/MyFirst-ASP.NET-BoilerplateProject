using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace MyLearningProject.Localization;

public static class MyLearningProjectLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(MyLearningProjectConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(MyLearningProjectLocalizationConfigurer).GetAssembly(),
                    "MyLearningProject.Localization.SourceFiles"
                )
            )
        );
    }
}
