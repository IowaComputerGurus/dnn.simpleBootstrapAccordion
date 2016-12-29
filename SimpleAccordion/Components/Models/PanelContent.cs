namespace ICG.Modules.SimpleBootstrapAccordion.Components.Models
{
    /// <summary>
    ///     Represents the content of a single tab
    /// </summary>
    public class PanelContent
    {
        /// <summary>
        ///     Gets or sets the panel content identifier.
        /// </summary>
        /// <value>The tab content identifier.</value>
        public int PanelContentId { get; set; }

        /// <summary>
        ///     Gets or sets the module identifier.
        /// </summary>
        /// <value>The module identifier.</value>
        public int ModuleId { get; set; }

        /// <summary>
        ///     Gets or sets the tab title.
        /// </summary>
        /// <value>The tab title.</value>
        public string PanelTitle { get; set; }

        /// <summary>
        ///     Gets or sets the tab contents.
        /// </summary>
        /// <value>The tab contents.</value>
        public string PanelContents { get; set; }

        /// <summary>
        ///     Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public int SortOrder { get; set; }

        #region Calculated Properties

        /// <summary>
        ///     Identifier to be used for the div id within the bootstrap implementation
        /// </summary>
        /// <value>icg_bst_(ModuleId)_(ContentId)</value>
        public string PanelBootstrapId => $"icg_bst_{ModuleId}_{PanelContentId}";

        #endregion
    }
}