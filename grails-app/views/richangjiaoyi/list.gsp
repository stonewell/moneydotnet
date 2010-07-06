
<%@ page import="angelstone.money.grail.Richangjiaoyi" %>
<html>
  <head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <meta name="layout" content="main" />
  <g:set var="entityName" value="${message(code: 'richangjiaoyi.label', default: 'Richangjiaoyi')}" />
  <title><g:message code="default.list.label" args="[entityName]" /></title>
</head>
<body>
  <div class="nav">
    <span class="menuButton"><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></span>
    <span class="menuButton"><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></span>
  </div>
  <div class="body">
    <h1><g:message code="default.list.label" args="[entityName]" /></h1>
    <g:if test="${flash.message}">
      <div class="message">${flash.message}</div>
    </g:if>
    <div class="list">
      <table>
        <thead>
          <tr>

        <g:sortableColumn property="id" title="${message(code: 'richangjiaoyi.id.label', default: 'Id')}" />

        <g:sortableColumn property="fangxiang" title="${message(code: 'richangjiaoyi.fangxiang.label', default: 'Fangxiang')}" />

        <g:sortableColumn property="name" title="${message(code: 'richangjiaoyi.name.label', default: 'Name')}" />

        <g:sortableColumn property="amount" title="${message(code: 'richangjiaoyi.amount.label', default: 'Amount')}" />

        <th><g:message code="richangjiaoyi.fenlei.label" default="Fenlei" /></th>

        <th><g:message code="richangjiaoyi.fangshi.label" default="Fangshi" /></th>

        <g:sortableColumn property="created" title="${message(code: 'richangjiaoyi.created.label', default: 'Created')}" />
        </tr>
        </thead>
        <tbody>
        <g:each in="${richangjiaoyiInstanceList}" status="i" var="richangjiaoyiInstance">
          <tr class="${(i % 2) == 0 ? 'odd' : 'even'}">

            <td><g:link action="show" id="${richangjiaoyiInstance.id}">${fieldValue(bean: richangjiaoyiInstance, field: "id")}</g:link></td>

          <td>${richangjiaoyiInstance.fangxiang == 0 ? "Expense" : "Incoming"}</td>

          <td>${fieldValue(bean: richangjiaoyiInstance, field: "name")}</td>

          <td>${fieldValue(bean: richangjiaoyiInstance, field: "amount")}</td>

          <td>${fieldValue(bean: richangjiaoyiInstance, field: "fenlei")}</td>

          <td>${fieldValue(bean: richangjiaoyiInstance, field: "fangshi")}</td>

          <td>${fieldValue(bean: richangjiaoyiInstance, field: "created")}</td>

          </tr>
        </g:each>
        </tbody>
      </table>
    </div>
    <div class="paginateButtons">
      <g:paginate total="${richangjiaoyiInstanceTotal}" max="40"/>
    </div>
  </div>
</body>
</html>
