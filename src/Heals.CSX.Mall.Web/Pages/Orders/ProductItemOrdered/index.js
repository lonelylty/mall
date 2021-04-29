$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.orders.productItemOrdered;
    var createModal = new abp.ModalManager(abp.appPath + 'Orders/ProductItemOrdered/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Orders/ProductItemOrdered/EditModal');

    var dataTable = $('#ProductItemOrderedTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                visible: abp.auth.isGranted('Mall.ProductItemOrdered.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.ProductItemOrdered.Delete'),
                                confirmMessage: function (data) {
                                    return l('ProductItemOrderedDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            { data: "productId" },
            { data: "productSeqId" },
            { data: "productName" },
            { data: "pictureUri" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductItemOrderedButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
