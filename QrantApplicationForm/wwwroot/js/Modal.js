$("#exampleModalCenter").on("show.bs.modal", function (e)
{
    setTimeout(() => {
        $("#exampleModalCenter").modal('hide');
    }, 2000);
})

