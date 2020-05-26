((function () {
    var url;
    var redirectUrl;
    var target;

    $('body').append(`
            <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title" id="myModalLabel">Warning</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>                    
                </div>
                <div class="modal-body delete-modal-body">                    
                </div>
                <div class="modal-footer">
                     <button type="button" class="btn btn-danger" id="confirm-delete">Delete</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal" id="cancel-delete">Cancel</button>
                  
                </div>
                </div>
            </div>
            </div>`);

    $(".delete").on('click', (e) => {
        e.preventDefault();

        target = e.target;
        var Id = $(target).data('id');
        var controller = $(target).data('controller');
        var action = $(target).data('action');
        var bodyMessage = $(target).data('body-message');
        redirectUrl = "/" + controller + "/" + "GetOrderList";

        url = "/" + controller + "/" + action + "?Id=" + Id;
        $(".delete-modal-body").text(bodyMessage);
        $("#deleteModal").modal('show');
    });

    $("#confirm-delete").on('click', () => {
        $.get(url)
            .done((result) => {
                window.location.href = redirectUrl;
            })
            .always(() => {
                $("#deleteModal").modal('hide');
            });
    });

}()));