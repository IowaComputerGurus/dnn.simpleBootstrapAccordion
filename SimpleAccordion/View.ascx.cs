using System;
using System.Text;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Security;
using DotNetNuke.Services.Cache;
using DotNetNuke.UI.Skins.Controls;
using ICG.Modules.SimpleBootstrapAccordion.Components.Repositories;
using ICG.Modules.SimpleBootstrapAccordion.Components.Utility;

namespace ICG.Modules.SimpleBootstrapAccordion
{
    public partial class View : PortalModuleBase, IActionable
    {

        #region IActionable Implementation

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var Actions = new ModuleActionCollection
                {
                    {
                        GetNextActionID(), LocalizeString("AddPanel"), "", "", "",
                        ModuleContext.EditUrl("pci", "-1", "EditContent"), false,
                        SecurityAccessLevel.Edit, true, false
                    }
                };
                return Actions;
            }
        }

        #endregion

        protected void Page_load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var editLink = string.Empty;

                if (IsEditable)
                {
                    editLink = $"<p><a href=\"{ModuleContext.EditUrl("pci", "-1", "EditContent")}\" class=\"btn btn-primary\">{LocalizeString("EditPanel")}</a></p>";
                }

                //Check for cached content
                var cachedContent = CachingProvider.Instance().GetItem("ICG_BSA_" + ModuleId);
                if (cachedContent != null && !ModuleContext.IsEditable)
                {
                    litContent.Text = cachedContent.ToString();
                }
                else
                {
                    //Build the items needed
                    var accordionId = $"ICG-SBA-{ModuleId}";
                    var multiSelect = "false"; //TODO: Future setting
                    var isExpanded = true; //TODO: Future panel setting
                    var wrapperContent = TemplateUtility.GetTemplate("AccordionWrapper");
                    var itemTemplate = TemplateUtility.GetTemplate("AccordionItem");

                    //Get the content
                    var panelBuilder = new StringBuilder();
                    var items = PanelContentRepository.GetModulePanelContents(ModuleId);
                    if (items.Count > 0)
                    {
                        var isFirstItem = true;
                        foreach (var item in items)
                        {
                            panelBuilder.Append(itemTemplate);
                            panelBuilder.Replace("[PANELCONTENTID]", item.PanelContentId.ToString());
                            panelBuilder.Replace("[EXPANDED]", isFirstItem.ToString().ToLowerInvariant());
                            panelBuilder.Replace("[HEADERCLASSATTRIBUTE]",
                                isFirstItem ? string.Empty : "class=\"collapsed\"");
                            panelBuilder.Replace("[PANELTITLE]", item.PanelTitle);
                            panelBuilder.Replace("[PANELCONTENTCLASS]", isFirstItem ? " in" : string.Empty);
                            panelBuilder.Replace("[PANELCONTENT]", item.PanelContents);
                            panelBuilder.Replace("[EDITLINK]", editLink.Replace("-1", item.PanelContentId.ToString()));
                            isFirstItem = false;
                        }

                        //Build the final one
                        var finalBuilder = new StringBuilder(wrapperContent);
                        finalBuilder.Replace("[ITEMS]", panelBuilder.ToString());
                        finalBuilder.Replace("[ACCORDIONID]", accordionId);
                        finalBuilder.Replace("[MULTISELECT]", multiSelect);
                        litContent.Text = finalBuilder.ToString();
                        if (!IsEditable)
                            CachingProvider.Instance().Insert("ICG_BSA_" + ModuleId, litContent.Text);
                    }
                    else
                    {
                        DotNetNuke.UI.Skins.Skin.AddModuleMessage(this, LocalizeString("NotItems"),
                            ModuleMessage.ModuleMessageType.BlueInfo);
                    }

                    
                }
            }
        }
    }
}