<div class="list, tableContainer" id="tableContainer">
  <table>
    <thead class="fixedHeader">
      <tr>
        <th class="sortable" nowrap>
          <g:message code="${summary?.title}" default="${summary?.title_default}" />
        </th>
        <th></th>
    </tr>
    <tr>
    <g:sortableColumn property="name" title="${message(code: 'richangjiaoyi.name.label', default: 'Name')}" />
    <g:sortableColumn property="amount" title="${message(code: 'richangjiaoyi.amount.label', default: 'Amount')}" />
    </tr>
    </thead>
    <g:render template="rangeItemSummaryBodyTemplate"  model="[summary:summary]"/>
  </table>
</div>