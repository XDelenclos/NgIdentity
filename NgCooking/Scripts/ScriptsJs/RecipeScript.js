$(document).ready(function () {
    $('#btn_showmore').hide();
});

$('#IndexRecette').change(function () {
    console.log($("#IndexRecette").val());

    var recipe_Id="" ;
    $('.displayResult #id').each(function () {
        console.log($(this).text());
        recipe_Id+= $(this).text()+"/";
    });

    console.log(recipe_Id);
     
    var dataselect = $('#IndexRecette').val() + "/" + recipe_Id;
    console.log(dataselect);
    $.ajax({
        type: "GET",
        url: ("Recipes/RecipesIndexer/?id="+dataselect), 
        success: function (data) { 
            $('#displayResult').html(data) },
        error: function (data) {
            $('#displayResult').html(data)
        }

    });
})

