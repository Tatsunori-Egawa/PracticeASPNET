﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.App.App1.WebForm1" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="ja" lang="ja">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta http-equiv="Content-Script-Type" content="text/javascript" />
    <meta http-equiv="Content-Style-Type" content="text/css" />
    <script type="text/javascript" src="<%=VirtualPathUtility.ToAbsolute("~/Scripts/jquery-1.4.1.js") %>"></script>
    <title>テスト</title>
    <script type="text/javascript">
        $(document).ready(function () {
            // --
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <dl>
            <dt>名前</dt><dd><asp:TextBox ID="txt1" runat="server"></asp:TextBox></dd>
            <dt>メモ</dt><dd><asp:TextBox ID="txt2" runat="server" Rows="5" TextMode="MultiLine"></asp:TextBox></dd>
            <dt>ボタン</dt><dd><asp:Button ID="btnSend" runat="server" Text="送信" onclick="btnSend_Click" /></dd>
            <dt>結果</dt><dd><asp:Label ID="lblResult" runat="server" Text=""></asp:Label></dd>
        </dl>
    </form>
</body>
</html>
