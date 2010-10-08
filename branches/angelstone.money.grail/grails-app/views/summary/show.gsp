
<%@ page %>

<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="layout" content="main" />
  <g:set var="entityName" value="${message(code: 'today.summary.label', default: 'Today Summary')}" />
  <title><g:message code="default.show.label" args="[entityName]" /></title>
  <g:render template="scriptsTemplate" />
</head>
<body onload="onPageload()">
  <div class="nav">
    <span class="menuButton"><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></span>
  </div>
  <div class="body">
    <h1><g:message code="default.show.label" args="[entityName]" /></h1>
    <g:if test="${flash.message}">
      <div class="message">${flash.message}</div>
    </g:if>
    <table border="0">
      <tr>
        <td>
      <g:render template="rangeSummaryTemplate"  model="[summary:summary?.YearSummary]"/>
      </td>
      <td>
      <g:render template="rangeItemSummaryTemplate"  model="[summary:summary?.ItemYearSummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FenleiYearSummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FangshiYearSummary]"/>
      </td>
      </tr>
      <tr>
        <td>
      <g:render template="rangeSummaryTemplate"  model="[summary:summary?.MonthSummary]"/>
      </td>
      <td>
      <g:render template="rangeItemSummaryTemplate"  model="[summary:summary?.ItemMonthSummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FenleiMonthSummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FangshiMonthSummary]"/>
      </td>
      </tr>
      <tr>
        <td>
      <g:render template="rangeSummaryTemplate"  model="[summary:summary?.TodaySummary]"/>
      </td>
      <td>
      <g:render template="rangeItemSummaryTemplate"  model="[summary:summary?.ItemTodaySummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FenleiTodaySummary]"/>
      </td>
      <td>
      <g:render template="rangeNameAmountSummaryTemplate"  model="[summary:summary?.FangshiTodaySummary]"/>
      </td>
      </tr>
    </table>
  </div>
</body>
</html>