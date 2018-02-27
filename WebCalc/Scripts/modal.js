////$('#myModal').on('shown.bs.modal', function () {
////    $('#myInput').focus()
////})
//debugger
//$('#exampleModal').on('show.bs.modal', function (event) {
//    $('#message-text').focus()
//    var button = $(event.relatedTarget) // Button that triggered the modal
//    var recipient = button.data('whatever') // Extract info from data-* attributes
//    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
//    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
//    var modal = $(this)
//    modal.find('#bodyte').text('@Html.Action("OpenDoc", new { id = ' +recipient + "})")
//    //modal.find('.modal-body input').attr('value', "SUUKA")
//})

//$(document).ready(function () {
//    //при нажатию на любую кнопку, имеющую класс .btn
//    $(".btn").click(function () {
//        //открыть модальное окно с id="myModal"
//        $("#myModal").modal('show');
//    });
//});

////$('#myModal2').on('shown.bs.modal', function (event) {
////    $('#message-text').focus()
////});

////$('#myModal3').on('show.bs.modal', function (event) {
////    $('#myInput').focus()
////    var button2 = $(event.relatedTarget) // Button that triggered the modal
////    var Docment = button2.data('whatever2') // Extract info from data-* attributes
////    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
////    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
////    var modal = $(this)
////    modal.find('#mb').text(Docment)
////    var su = "'"
////    //var deleteUrl = 'location.href=' + su + '@Url.Action("Delete"';
////    //modal.find('#delAnswer').attr('onclick', deleteUrl+ ', new{ id = ' +ident+ '})'+su)
////    modal.find('#message-text3').attr('value', Docment.Document)
////})


////$('#NewDoc').on('show.bs.modal', function (event) {
////    var button = $(event.relatedTarget) // Button that triggered the modal
////    var recipient = button.data('whatever') // Extract info from data-* attributes
////    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
////    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
////    var modal = $(this)
////    modal.find('.modal-title').text('New message to ' + recipient)
////    modal.find('.modal-body input').val(recipient)
////})



////$("#myModal2").on('show.bs.modal', function (e) {
////    $('#emailInput').focus();
////    var userId = $(e.relatedTarget).data('whatever2');
////    var modal = $(this);
////    modal.find('#emailInput').attr('value', userId);
////    var content = $(e.relatedTarget).data('whatever2');
////    modal.find('#content').text(content);
////    modal.find('.modal-body').val(userId);
////});

////$("#myModal2").on('hidden.bs.modal', function () {
////    var form = $(this).find('form');
////    form[0].reset();
////});