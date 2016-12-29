using System;
using DotNetNuke.Common;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Cache;
using DotNetNuke.UI.UserControls;
using ICG.Modules.SimpleBootstrapAccordion.Components.Models;
using ICG.Modules.SimpleBootstrapAccordion.Components.Repositories;

namespace ICG.Modules.SimpleBootstrapAccordion.Modals
{
    /// <summary>
    ///     UI control for editing content within the tabs
    /// </summary>
    public partial class EditContent : PortalModuleBase
    {
        /// <summary>
        ///     Gets the tab content identifier.
        /// </summary>
        /// <value>The tab content identifier.</value>
        private int PanelContentId
        {
            get
            {
                if (Request.QueryString["pci"] != null)
                    return int.Parse(Request.QueryString["pci"]);
                else
                    return -1;
            }
        }

        /// <summary>
        ///     Text editor UI control for Panel content
        /// </summary>
        /// <remarks>
        ///     DO NOT REMOVE: Needed for Visual Studio editor integration
        /// </remarks>
        protected TextEditor txtPanelContent;

        /// <summary>
        ///     Page_s the load.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (PanelContentId > 0)
                {
                    var toEdit = PanelContentRepository.GetPanelContentByPanelContentId(ModuleId, PanelContentId);
                    txtPanelContent.Text = toEdit.PanelContents;
                    txtPanelTitle.Text = toEdit.PanelTitle;
                    txtSortOrder.Text = toEdit.SortOrder.ToString();
                    liDelete.Visible = true;
                }
                else
                {
                    txtSortOrder.Text = "0";
                }
            }
        }

        /// <summary>
        ///     BTNs the cancel_ click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect(Globals.NavigateURL(TabId));
        }

        /// <summary>
        ///     BTNs the delete_ click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PanelContentRepository.DeletePanelContent(ModuleId, PanelContentId);
            CachingProvider.Instance().Remove("ICG_BSA_" + ModuleId);
            btnCancel_Click(sender, e);
        }

        /// <summary>
        ///     BTNs the save_ click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var toSave = new PanelContent
                         {
                             ModuleId = ModuleId,
                             SortOrder = int.Parse(txtSortOrder.Text),
                             PanelContentId = PanelContentId,
                             PanelContents = txtPanelContent.Text,
                             PanelTitle = txtPanelTitle.Text
                         };
            PanelContentRepository.SavePanelContent(toSave);

            //Clear Cache
            CachingProvider.Instance().Remove("ICG_BSA_" + ModuleId);
            btnCancel_Click(sender, e);
        }
    }
}