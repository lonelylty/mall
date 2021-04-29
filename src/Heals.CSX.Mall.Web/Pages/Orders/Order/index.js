$(function () {

    var l = abp.localization.getResource('Mall');

    var service = heals.cSX.mall.orders.order;
    var createModal = new abp.ModalManager(abp.appPath + 'Orders/Order/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Orders/Order/EditModal');

    var dataTable = $('#OrderTable').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                                visible: abp.auth.isGranted('Mall.Order.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                visible: abp.auth.isGranted('Mall.Order.Delete'),
                                confirmMessage: function (data) {
                                    return l('OrderDeletionConfirmationMessage', data.record.id);
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
            { data: "orderNo" },
            { data: "buyerId" },
            { data: "buyer" },
            { data: "shipToAddressId" },
            { data: "shipToAddress" },
            { data: "status" },
            { data: "orderDate" },
            { data: "targetDeliveryDate" },
            { data: "actualDeliveryDate" },
            { data: "orderItems" },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewOrderButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
