var selectedSong ='song1';
$(document).ready(function(){

$('#btnSave').bind('click',GetLyrics);

$( ".list-group-item" ).on( "click", function(){

        $(".list-group-item" ).removeClass('list-group-item active').addClass('list-group-item');
        $(this).removeClass("list-group-item").addClass("list-group-item active");
        selectedSong = $(this).text();

    });

});


function GetLyrics(song){

    $('#btnSave').click(function(){
    
    $.ajax({
        url:'http://api.lololyrics.com/0.5/getLyric?artist=Prefix&track=rihana',
        //url: 'https://api.musixmatch.com/ws/1.1/track.lyrics.get?format=jsonp&callback=callback&track_id=15953433',// url
        dataType: "json",
        type: "GET", 
        contentType: 'application/json; charset=utf-8', 
        cache: false, 
        success: function (data) {
            $('#lyrics').html(data);
            if (data.success) { 
                $('#lyrics').html(data);
                //alert(data.message);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
    
});


}


