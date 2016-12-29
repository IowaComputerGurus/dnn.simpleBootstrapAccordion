﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditContent.ascx.cs" Inherits="ICG.Modules.SimpleBootstrapAccordion.Modals.EditContent" %>
<%@ Register tagPrefix="dnn" tagName="Label" src="~/Controls/LabelControl.ascx" %>
<%@ Register tagPrefix="dnn" tagName="TextEditor" src="~/Controls/TextEditor.ascx" %>

<div class="dnnForm">
    
    <div class="dnnFormItem">
        <dnn:Label id="lblPanelTitle" runat="server" suffix=":" cssclass="dnnFormRequired" controlname="txtPanelTitle" />
        <asp:Textbox ID="txtPanelTitle" runat="server" MaxLength="500" />
        <asp:RequiredFieldValidator runat="server" ID="PanelTitleRequired" CssClass="dnnFormMessage dnnFormError" Display="Dynamic" ControlToValidate="txtPanelTitle" ResourceKey="RequiredField" />
    </div>

    <div class="dnnFormItem">
        <dnn:Label id="lblPanelContent" runat="server" suffix=":" cssclass="dnnFormRequired" controlname="txtPanelContent" />
        <dnn:TextEditor id="txtPanelContent" runat="server" htmlencode="false" />
    </div>
    
    <div class="dnnFormItem">
        <dnn:Label id="lblSortOrder" runat="server" suffix=":" cssclass="dnnFormRequired" controlname="txtSortOrder" />
        <asp:TextBox runat="server" ID="txtSortOrder" MaxLength="2" Columns="2" />
        <asp:CompareValidator runat="server" ID="SortOrderFormat" Display="dynamic" ControlToValidate="txtSortOrder" CssClass="dnnFormMessage dnnFormError" ResourceKey="NumberField" Operator="DataTypeCheck" Type="Integer" />
    </div>

    <ul class="dnnActions">
        <li><asp:LinkButton runat="server" ID="btnSave" ResourceKey="btnSave" CssClass="dnnPrimaryAction" OnClick="btnSave_Click" /></li>
        <li id="liDelete" runat="server" Visible="False"><asp:LinkButton ID="btnDelete" runat="server" ResourceKey="btnDelete" CssClass="dnnSecondaryAction" OnClick="btnDelete_Click" /></li>
        <li><asp:LinkButton runat="server" ID="btnCancel" ResourceKey="btnCancel" CssClass="dnnSecondaryAction" OnClick="btnCancel_Click" /></li>
    </ul>
</div>