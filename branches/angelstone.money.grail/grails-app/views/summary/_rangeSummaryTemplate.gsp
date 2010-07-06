<div class="list">
  <table>
    <thead>
      <tr>
        <th class="sortable sorted" colspan="2">
    <g:message code="${summary?.title}"
               default="${summary?.title_default}" />
    </th>
    </tr>
    </thead>
    <tbody>
      <tr class="even">
        <td>
    <g:message code="${summary?.begin_label}"
               default="${summary?.begin_label_default}" />
    </td>
    <td>
    <g:formatNumber number="${summary?.begin_amount}" type="currency" currencyCode="CNY" currencySymbol="" />
    </td>
    </tr>
    <tr class="odd">
      <td>
    <g:message code="${summary?.expends_label}"
               default="${summary?.expends_label_default}" />
    </td>
    <td>
    <g:formatNumber number="${summary?.expends_amount}" type="currency" currencyCode="CNY" currencySymbol="" />
    </td>
    </tr>
    <tr class="even">
      <td>
    <g:message code="${summary?.incoming_label}"
               default="${summary?.incoming_label_default}" />
    </td>
    <td>
    <g:formatNumber number="${summary?.incoming_amount}" type="currency" currencyCode="CNY" currencySymbol="" />
    </td>
    </tr>
    <tr class="odd">
      <td>
    <g:message code="${summary?.end_label}"
               default="${summary?.end_label_default}" />
    </td>
    <td>
    <g:formatNumber number="${summary?.end_amount}" type="currency" currencyCode="CNY" currencySymbol="" />
    </td>
    </tr>
    </tbody>
  </table>
</div>
