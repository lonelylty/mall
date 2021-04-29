$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.orders.orderItem;
    var createModal = new abp.ModalManager(abp.appPath + 'Orders/OrderItem/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Orders/OrderItem/EditModal');

    var dataTable = $('#OrderItemTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Mall.OrderItem.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.OrderItem.Delete'),
                                confirmMessage: function (data) {
                                    return l('OrderItemDeletionConfirmationMessage', data.record.id);
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
            { data: "itemOrderedId" },
            { data: "itemOrdered" },
            { data: "unitPrice" },
            { data: "units" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewOrderItemButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
