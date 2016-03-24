<%dbdns="../"%>
<!--#include file="../inc/conn.asp"-->

<%if session("admin")="" then
  		response.write"<script>window.open('index.asp','_parent')</script>"
end if%>
<%=citycss%>

