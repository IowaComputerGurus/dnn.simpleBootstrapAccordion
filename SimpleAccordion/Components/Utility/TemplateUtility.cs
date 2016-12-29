using System.IO;
using System.Web;

namespace ICG.Modules.SimpleBootstrapAccordion.Components.Utility
{
    /// <summary>
    ///     Helper class for working with template files
    /// </summary>
    public static class TemplateUtility
    {
        private const string BaseRelativeDirectoryPath = "~/DesktopModules/ICG/SimpleBootstrapAccordion/Templates";

        /// <summary>
        ///     Gets the template.
        /// </summary>
        /// <param name="templateName">Name of the template.</param>
        /// <returns></returns>
        public static string GetTemplate(string templateName)
        {
            return GetTemplate(templateName, HttpContext.Current.Server.MapPath(BaseRelativeDirectoryPath));
        }

        /// <summary>
        ///     Gets the template.
        /// </summary>
        /// <param name="templateName">Name of the template.</param>
        /// <param name="templatePath">The template path.</param>
        /// <returns></returns>
        public static string GetTemplate(string templateName, string templatePath)
        {
            var key = templateName + "_ViewTemplate";
            //Get from cache
            if (CacheUtility.CacheExists(key))
                return CacheUtility.GetItemFromCache<string>(key);

            //Get from path, store to cache then return
            var toGet = Path.Combine(templatePath + "/", templateName + ".html");
            var data = File.ReadAllText(toGet);
            CacheUtility.SetCache(data, key);
            return data;
        }

        /// <summary>
        ///     Updates the template.
        /// </summary>
        /// <param name="templateName">Name of the template.</param>
        /// <param name="templateContents">The template contents.</param>
        public static void UpdateTemplate(string templateName, string templateContents)
        {
            var toUpdate = HttpContext.Current.Server.MapPath(BaseRelativeDirectoryPath) + "/" + templateName + ".html";
            File.WriteAllText(toUpdate, templateContents);
        }
    }
}