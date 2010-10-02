<div class="dialog">
  <table>
    <tbody>

      <tr class="prop">
        <td valign="top" class="name">
          <label for="fangxiang"><g:message code="richangjiaoyi.fangxiang.label" default="Fangxiang" /></label>
        </td>
        <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'fangxiang', 'errors')}">
    <g:radioGroup name="fangxiang" values="[0,1]"
                  value="${richangjiaoyiInstance?.fangxiang}" labels="['Expends', 'Incoming']">
${it.radio} <g:message code="${it.label}" />
    </g:radioGroup>
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="name"><g:message code="richangjiaoyi.name.label" default="Name" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'name', 'errors')}">
    <g:textField name="name" id="name" maxlength="50" value="${richangjiaoyiInstance?.name}" />
    <g:select name="names" id="names" onchange="updateName(this.value)"/>
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="amount"><g:message code="richangjiaoyi.amount.label" default="Amount" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'amount', 'errors')}">
    <g:textField name="amount" value="${fieldValue(bean: richangjiaoyiInstance, field: 'amount')}" />
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="fenlei"><g:message code="richangjiaoyi.fenlei.label" default="Fenlei" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'fenlei_id', 'errors')}">
    <g:select name="fenlei_id" id="fenlei_id"
              from="${angelstone.money.grail.Fenlei.list()}"
              optionKey="id" value="${richangjiaoyiInstance?.fenlei_id}"
              onchange="${remoteFunction(
controller:'richangjiaoyi', 
action:'ajaxGetJiaoYiNames', 
params:'\'fenlei=\' + escape(this.value)', 
onComplete:'updateNames(e)')}"
              />
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="fangshi"><g:message code="richangjiaoyi.fangshi.label" default="Fangshi" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'fangshi_id', 'errors')}">
    <g:select name="fangshi_id" id="fangshi_id" from="${angelstone.money.grail.Fangshi.list()}"
              optionKey="id" value="${richangjiaoyiInstance?.fangshi_id}"
              />
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="description"><g:message code="richangjiaoyi.description.label" default="Description" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'description', 'errors')}">
    <g:textArea name="description" cols="40" rows="5" value="${richangjiaoyiInstance?.description}" />
    </td>
    </tr>

    <tr class="prop">
      <td valign="top" class="name">
        <label for="created"><g:message code="richangjiaoyi.created.label" default="Created" /></label>
      </td>
      <td valign="top" class="value ${hasErrors(bean: richangjiaoyiInstance, field: 'created', 'errors')}">
    <g:datePicker name="created" precision="day" value="${richangjiaoyiInstance?.created}"  />
    </td>
    </tr>

    </tbody>
  </table>
</div>

