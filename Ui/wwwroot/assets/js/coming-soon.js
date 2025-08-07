(function () {
	"use strict";
	
	 function makeTimer(end_date) {
    
           var endTime = new Date(end_date);   
           endTime = (Date.parse(endTime) / 1000);
        
           var now = new Date();
           now = (Date.parse(now) / 1000);
        
           var timeLeft = endTime - now;
        
           var days = Math.floor(timeLeft / 86400); 
           var hours = Math.floor((timeLeft - (days * 86400)) / 3600);
           var minutes = Math.floor((timeLeft - (days * 86400) - (hours * 3600 )) / 60);
		   var seconds = Math.floor((timeLeft - (days * 86400) - (hours * 3600) - (minutes * 60)));
          
           if (hours < "10") { hours = "0" + hours; }
           if (minutes < "10") { minutes = "0" + minutes; }
           if (seconds < "10") { seconds = "0" + seconds; }
        
           $("#days").html(days + "<span>Days</span>");
           $("#hours").html(hours + "<span>Hours</span>");
           $("#minutes").html(minutes + "<span>Minutes</span>");
           $("#seconds").html(seconds + "<span>Seconds</span>");  
    
     }
    
     setInterval(function() { var end_date =$("#end_time").val();  makeTimer(end_date); }, 1000);
  
}(jQuery));		
	
	