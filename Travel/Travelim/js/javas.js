// document.onmousemove = animateBall;
// var colors = ['#ccc','#6cf','eba13a'];
// function animateBall (event) {
//    var ball = document.createElement("div");
//    ball.setAttribute("class","ball");
//    document.body.appendChild(ball);
//    ball.style.left = event.clientX + "px";
//    ball.style.top = event.clientY + "px";

//    var color = colors[Math.floor(Math.random() * colors.length)];
//    ball.style.background = color;
//    ball.style.transition = "all 0.5s linear 0s";

//    ball.style.left = ball.offsetLeft - 30 + 'px';
//    ball.style.top = ball.offsetTop - 30 + 'px';

//    ball.style.width = "50px;"
//    ball.style.height = "50px;"
//    ball.style.borderWidth = "5px;"
//    ball.style.opacity = 0;
// }

// //



// $(window).scroll(function(){
   
   
//    $("#navbaritem").css({
//       position : 'fixed',
//       width :  '1500px',
//       transition: 'all 0.1s linear',
//       zIndex : '11111'
//    })
//    if($(window).scrollTop()==0){
//        $("#navbaritem").css("position","static"),
//        $("#navbaritem").css("transition","all 0.1s linear")
//    }
// })






//maps
 function initMap() {
        var uluru = {lat: -25.363, lng: 131.044};
        var map = new google.maps.Map(document.getElementById('map'), {
          zoom: 4,
          center: uluru
        });
        var marker = new google.maps.Marker({
          position: uluru,
          map: map
        });
      }



//

//



$(document).ready(function(){
   $('.toggle').click(function(){
      $('ul').toggleClass('active');
   })
})


$(window).on('scroll',function(){
   if($(window).scrollTop()){
      $('nav').addClass('black');
   
   }
   else{
      $('nav').removeClass('black');
   }
})




$('#Show').click(function(){

  $('#Show').css('display','none');
  $('#item').css('display','none');
  $('#data').show();
  $('#Hide').show();

});
$('#Hide').click(function(){

  $('#Hide').css('display','none');
  $('#data').hide();
  $('#Show').show();
  $('#item').show();


});

