﻿<%@ Page Title="Log in" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ShantaraProduction.Login" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<br />
	<br />
	<br />
	<h1><%: Title %></h1>
	<br />
	<div class="row">
		<hr />
		<div class="col-md-8">
			<section id="loginForm">
				<div class="form-horizontal">
					<asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
						<p class="text-danger">
							<asp:Literal runat="server" ID="FailureText" />
						</p>
					</asp:PlaceHolder>
					<div class="form-group">
						<asp:Label runat="server" AssociatedControlID="ddlUsername" CssClass="col-md-2 control-label">Username</asp:Label>
						<div class="col-md-6">
							<asp:DropDownList ID="ddlUsername" CssClass="form-control" data-provide="typeahead" Style="height: 34px; width: 100%; max-width: none" runat="server" AutoPostBack="true"
								AppendDataBoundItems="True">
								<asp:ListItem Text="--Select Username--" Value=""></asp:ListItem>
							</asp:DropDownList>
						 <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlUsername"
								CssClass="text-danger" ErrorMessage="The Username field is required." />
						</div>
					</div>
					<div class="form-group">
						<asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
						<div class="col-md-6">
							<asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" Style="height: 34px; width: 100%; max-width: 100%" />
							<asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
						</div>
					</div>
					<%--<div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>--%>
					<div class="form-group">
						<div class="col-md-offset-2 col-md-6">
							<asp:LinkButton runat="server" OnClick="LogIn" Text="Log in" CssClass="btn btn-default btn-lg"><span class="glyphicon glyphicon-log-in" aria-hidden="true"></span> Log In</asp:LinkButton>
							<%--<button type="button" class="btn btn-default btn-lg">
                    <span class="glyphicon glyphicon-send" aria-hidden="true"></span>
                    Submit job ticket
                </button>--%>
						</div>
					</div>
				</div>
				<%-- Enable this once you have account confirmation enabled for password reset functionality
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Forgot your password?</asp:HyperLink>
				--%>
			</section>
		</div>
		<div class="col-md-4">
			<a runat="server" href="~/">
				<asp:Image ID="ShantaraLogo" runat="server" ImageUrl="~/Images/Shantara_Logo.jpg" BorderStyle="Solid" />
			</a>
		</div>
	</div>
</asp:Content>
