using System.Collections.Generic;
using DotNetNuke.Common.Utilities;
using DotNetNuke.Data;
using ICG.Modules.SimpleBootstrapAccordion.Components.Models;

namespace ICG.Modules.SimpleBootstrapAccordion.Components.Repositories
{
    /// <summary>
    ///     Repository class for tab content interaction
    /// </summary>
    public static class PanelContentRepository
    {
        /// <summary>
        ///     Gets the module panel contents.
        /// </summary>
        /// <param name="moduleId">The module identifier.</param>
        /// <returns>List&lt;TabContent&gt;.</returns>
        public static List<PanelContent> GetModulePanelContents(int moduleId)
        {
            return
                CBO.FillCollection<PanelContent>(
                    DataProvider.Instance().ExecuteReader("ICG_BSA_PanelContentSelectByModuleId", moduleId));
        }

        /// <summary>
        ///     Gets the panel content by panel content identifier.
        /// </summary>
        /// <param name="moduleId">The module identifier.</param>
        /// <param name="panelContentId">The tab content identifier.</param>
        /// <returns>TabContent.</returns>
        public static PanelContent GetPanelContentByPanelContentId(int moduleId, int panelContentId)
        {
            return
                CBO.FillObject<PanelContent>(
                    DataProvider.Instance()
                        .ExecuteReader("ICG_BSA_PanelContentSelectByModuleIdAndContentId", moduleId, panelContentId));
        }

        /// <summary>
        /// Deletes the content of the panel.
        /// </summary>
        /// <param name="moduleId">The module identifier.</param>
        /// <param name="panelContentId">The tab content identifier.</param>
        public static void DeletePanelContent(int moduleId, int panelContentId)
        {
            DataProvider.Instance().ExecuteNonQuery("ICG_BSA_PanelContentDelete", moduleId, panelContentId);
        }

        /// <summary>
        ///     Saves the content of the panel.
        /// </summary>
        /// <param name="toSave">To save.</param>
        public static void SavePanelContent(PanelContent toSave)
        {
            DataProvider.Instance()
                .ExecuteNonQuery("ICG_BSA_PanelContentSave", toSave.ModuleId, toSave.PanelContentId, toSave.PanelTitle,
                    toSave.PanelContents, toSave.SortOrder);
        }
    }
}