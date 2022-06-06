<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Cat_Solution.aspx.cs" Inherits="NetwiseAspNetCat.Cat_Solution" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cat</title>
</head>
<body>
    <h1>Rozwiązanie zadania</h1>
    <form id="form1" runat="server">
       
        <div id="right">
          
        </div>
        <div id="left"><br/>
              <asp:Button ID="ButtondownloadText"  runat="server" Text="Pobierz tekst" Width="178px" OnClick="ButtondownloadText_Click" /><br/><br/>
              <asp:Button ID="deleteFile" runat="server" Text="Usuń plik" Width="178px" OnClick="deleteFile_Click" /> <br/><br/>
              <asp:Button ID="clearWindow" runat="server" Text="Wyczyść okno" Width="178px" OnClick="clearWindow_Click" /> <br/>
         
        </div>
                
           <asp:TextBox ID="TextBoxCat" runat="server" Height="507px" Width="704px" TextMode="MultiLine"></asp:TextBox>
                
    </form>
</body>
</html>
<style>
     #left{
        width:50%;
        float:right;
        padding-left:1%;
    }
    #right{
        width:50%;
        float:right;
    }

</style>
