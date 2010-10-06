
<%@ page import="angelstone.diaryaccount.Entry" %>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
        <meta name="layout" content="main" />
        <g:set var="entityName" value="${message(code: 'entry.label', default: 'Entry')}" />
        <title><g:message code="default.create.label" args="[entityName]" /></title>
    </head>
    <body>
        <div class="nav">
            <span class="menuButton"><a class="home" href="${createLink(uri: '/')}"><g:message code="default.home.label"/></a></span>
            <span class="menuButton"><g:link class="list" action="list"><g:message code="default.list.label" args="[entityName]" /></g:link></span>
        </div>
        <div class="body">
            <h1><g:message code="default.create.label" args="[entityName]" /></h1>
            <g:if test="${flash.message}">
            <div class="message">${flash.message}</div>
            </g:if>
            <g:hasErrors bean="${entryInstance}">
            <div class="errors">
                <g:renderErrors bean="${entryInstance}" as="list" />
            </div>
            </g:hasErrors>
            <g:form action="save" method="post" >
                <div class="dialog">
                    <table>
                        <tbody>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="type"><g:message code="entry.type.label" default="Type" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'type', 'errors')}">
                                    <g:textField name="type" value="${fieldValue(bean: entryInstance, field: 'type')}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="name"><g:message code="entry.name.label" default="Name" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'name', 'errors')}">
                                    <g:textField name="name" maxlength="50" value="${entryInstance?.name}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="amount"><g:message code="entry.amount.label" default="Amount" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'amount', 'errors')}">
                                    <g:textField name="amount" value="${fieldValue(bean: entryInstance, field: 'amount')}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="description"><g:message code="entry.description.label" default="Description" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'description', 'errors')}">
                                    <g:textArea name="description" cols="40" rows="5" value="${entryInstance?.description}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="category"><g:message code="entry.category.label" default="Category" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'category', 'errors')}">
                                    <g:textField name="category" value="${entryInstance?.category}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="pay_method"><g:message code="entry.pay_method.label" default="Paymethod" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'pay_method', 'errors')}">
                                    <g:textField name="pay_method" value="${entryInstance?.pay_method}" />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="create_date"><g:message code="entry.create_date.label" default="Createdate" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'create_date', 'errors')}">
                                    <g:datePicker name="create_date" precision="day" value="${entryInstance?.create_date}"  />
                                </td>
                            </tr>
                        
                            <tr class="prop">
                                <td valign="top" class="name">
                                    <label for="pay_date"><g:message code="entry.pay_date.label" default="Paydate" /></label>
                                </td>
                                <td valign="top" class="value ${hasErrors(bean: entryInstance, field: 'pay_date', 'errors')}">
                                    <g:datePicker name="pay_date" precision="day" value="${entryInstance?.pay_date}"  />
                                </td>
                            </tr>
                        
                        </tbody>
                    </table>
                </div>
                <div class="buttons">
                    <span class="button"><g:submitButton name="create" class="save" value="${message(code: 'default.button.create.label', default: 'Create')}" /></span>
                </div>
            </g:form>
        </div>
    </body>
</html>
