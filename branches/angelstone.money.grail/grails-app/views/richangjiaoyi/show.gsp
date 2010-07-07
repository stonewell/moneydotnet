
<%@ page import="angelstone.money.grail.Richangjiaoyi" %>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="layout" content="main" />
        <g:set var="entityName" value="${message(code: 'richangjiaoyi.label', default: 'Richangjiaoyi')}" />
        <title><g:message code="default.show.label" args="[entityName]" /></title>
    </head>
    <body>
        <div class="nav">
            <span class="menuButton"><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></span>
            <span class="menuButton"><g:link class="list" action="list"><g:message code="default.list.label" args="[entityName]" /></g:link></span>
            <span class="menuButton"><g:link class="create" action="create"><g:message code="default.new.label" args="[entityName]" /></g:link></span>
        </div>
        <div class="body">
            <h1><g:message code="default.show.label" args="[entityName]" /></h1>
            <g:if test="${flash.message}">
            <div class="message">${flash.message}</div>
            </g:if>
            <div class="dialog">
                <table>
                    <tbody>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.id.label" default="Id" /></td>
                            
                            <td valign="top" class="value">${fieldValue(bean: richangjiaoyiInstance, field: "id")}</td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.fangxiang.label" default="Fangxiang" /></td>
                            
                            <td valign="top" class="value">${richangjiaoyiInstance?.fangxiang == 0 ? "Expense" : "Incoming"}</td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.name.label" default="Name" /></td>
                            
                            <td valign="top" class="value">${fieldValue(bean: richangjiaoyiInstance, field: "name")}</td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.amount.label" default="Amount" /></td>
                            
                            <td valign="top" class="value">${fieldValue(bean: richangjiaoyiInstance, field: "amount")}</td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.fenlei.label" default="Fenlei" /></td>
                            
                            <td valign="top" class="value"><g:link controller="fenlei" action="show" id="${richangjiaoyiInstance?.fenlei?.id}">${richangjiaoyiInstance?.fenlei?.encodeAsHTML()}</g:link></td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.fangshi.label" default="Fangshi" /></td>
                            
                            <td valign="top" class="value"><g:link controller="fangshi" action="show" id="${richangjiaoyiInstance?.fangshi?.id}">${richangjiaoyiInstance?.fangshi?.encodeAsHTML()}</g:link></td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.description.label" default="Description" /></td>
                            
                            <td valign="top" class="value">${fieldValue(bean: richangjiaoyiInstance, field: "description")}</td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.updated.label" default="Updated" /></td>
                            
                            <td valign="top" class="value"><g:formatDate date="${richangjiaoyiInstance?.updated}" /></td>
                            
                        </tr>
                    
                        <tr class="prop">
                            <td valign="top" class="name"><g:message code="richangjiaoyi.created.label" default="Created" /></td>
                            
                            <td valign="top" class="value"><g:formatDate date="${richangjiaoyiInstance?.created}" /></td>
                            
                        </tr>
                    
                    </tbody>
                </table>
            </div>
            <div class="buttons">
                <g:form>
                    <g:hiddenField name="id" value="${richangjiaoyiInstance?.id}" />
                    <span class="button"><g:actionSubmit class="edit" action="edit" value="${message(code: 'default.button.edit.label', default: 'Edit')}" /></span>
                    <span class="button"><g:actionSubmit class="delete" action="delete" value="${message(code: 'default.button.delete.label', default: 'Delete')}" onclick="return confirm('${message(code: 'default.button.delete.confirm.message', default: 'Are you sure?')}');" /></span>
                </g:form>
            </div>
        </div>
    </body>
</html>