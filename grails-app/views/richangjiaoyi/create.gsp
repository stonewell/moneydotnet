
<%@ page import="angelstone.money.grail.Richangjiaoyi" %>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="layout" content="main" />
        <g:set var="entityName" value="${message(code: 'richangjiaoyi.label', default: 'Richangjiaoyi')}" />
        <title><g:message code="default.create.label" args="[entityName]" /></title>
     		<g:render template="scriptsTemplate" model="[richangjiaoyiInstance:richangjiaoyiInstance]"/>
    </head>
    <body onload="initNames();">
        <div class="nav">
            <span class="menuButton"><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></span>
            <span class="menuButton"><g:link class="list" action="list"><g:message code="default.list.label" args="[entityName]" /></g:link></span>
        </div>
        <div class="body">
            <h1><g:message code="default.create.label" args="[entityName]" /></h1>
            <g:if test="${flash.message}">
            <div class="message">${flash.message}</div>
            </g:if>
            <g:hasErrors bean="${richangjiaoyiInstance}">
            <div class="errors">
                <g:renderErrors bean="${richangjiaoyiInstance}" as="list" />
            </div>
            </g:hasErrors>
            <g:form action="save" method="post" >
            		<g:render template="modifyTemplate" model="[richangjiaoyiInstance:richangjiaoyiInstance]"/>
                <div class="buttons">
                    <span class="button"><g:submitButton name="create" class="save" value="${message(code: 'default.button.create.label', default: 'Create')}" /></span>
                </div>
            </g:form>
        </div>
    </body>
</html>
