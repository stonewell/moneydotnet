<div class="list, tableContainer" id="tableContainer">
  <table  border="0" cellpadding="0" cellspacing="0" width="100%" class="scrollTable">
    <thead class="fixedHeader">
      <tr>
        <th class="sortable sorted"  colspan="2" nowrap>
    <g:message code="${summary?.title}" default="${summary?.title_default}" />
    <g:select name="fenlei.id" id="fenlei.id"
              from="${angelstone.money.grail.Fenlei.list()}"
              optionKey="id" value="${richangjiaoyiInstance?.fenlei?.id}"
              />
    <g:select name="fangshi.id" id="fangshi.id"
              from="${angelstone.money.grail.Fangshi.list()}"
              optionKey="id" value="${richangjiaoyiInstance?.fangshi?.id}"
              />
    </th>
    </tr>
    <tr>
    <g:sortableColumn property="name" title="${message(code: 'richangjiaoyi.name.label', default: 'Name')}" />
    <g:sortableColumn property="amount" title="${message(code: 'richangjiaoyi.amount.label', default: 'Amount')}" />
    </tr>
    </thead>
    <tbody class="scrollContent">
    <g:each in="${summary?.fenleiList}" status="i" var="fenleiInstance">
      <tr class="${(i % 2) == 0 ? 'odd' : 'even'}">
        <td>${fenleiInstance[0]}</td>

        <td><g:formatNumber number="${fenleiInstance[1]}"  type="currency" currencyCode="CNY" currencySymbol=""/></td>
      </tr>
    </g:each>
    </tbody>
  </table>
</div>
