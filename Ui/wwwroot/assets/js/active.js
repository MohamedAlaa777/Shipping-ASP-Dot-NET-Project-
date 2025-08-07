(function () {
	"use strict";
	

    jQuery(document).ready(function($){
		
		/*Home page main slider*/
		
        $(".homepage-slides").owlCarousel({
            items: 1,
            nav: true,
            dots: false,
            autoplay: true,
            loop: true,
            navText: ["<i class='fas fa-chevron-left'></i>", "<i class='fas fa-chevron-right'></i>"],
            mouseDrag: false,
            touchDrag: true,
			animateOut: 'fadeOut',
			autoplayTimeout:6000,  
			responsive:{
				0:{
					nav:false,
					dots: true
				},
				767:{
					nav:true,
					dots: false
				},
				1000:{
					nav:true,
					dots: false
				}
			}
        });
        
        $(".homepage-slides").on("translate.owl.carousel", function(){
            $(".single-slide-item h3, .single-slide-item p").removeClass("animated fadeInUp").css("opacity", "0");
            $(".single-slide-item .slide-btn, .single-slide-item h2").removeClass("animated fadeInDown").css("opacity", "0");
        });
        
        $(".homepage-slides").on("translated.owl.carousel", function(){
            $(".single-slide-item h3, .single-slide-item p").addClass("animated fadeInUp").css("opacity", "1");
            $(".single-slide-item .slide-btn, .single-slide-item h2").addClass("animated fadeInDown").css("opacity", "1");
        });
		
		/*For mobile menu*/
		
		$("ul#navigation").slicknav({
            prependTo: ".mobile-menu-wrapper"
        });
		
		/*Home page1 Testimonial*/
		
		$(".testimonial").owlCarousel({
            items: 1,
            nav: false,
            dots: true,
            autoplay: true,
            loop: true,
            mouseDrag: false,
            touchDrag: true
        });
		
		/*Home page2 Testimonial*/
		
		$(".testimonial2").owlCarousel({
            items: 1,
            nav: false,
            dots: true,
            autoplay: true,
            loop: true,
            mouseDrag: false,
            touchDrag: true
        });
		
		/*Client Carousel*/
		
		$(".our-client").owlCarousel({
            items: 6,
            nav: false,
			navText: ["<i class='fa fa-angle-left'></i>", "<i class='fa fa-angle-right'></i>"],
            dots: false,
            autoplay: true,
            loop: true,
            mouseDrag: false,
            touchDrag: true,
			responsiveClass:true,
			responsive:{
				0:{
					items:1,
					nav:true
				},
				380:{
					items:2,
					nav:true
				},
				600:{
					items:4,
					nav:false
				},
				1000:{
					items:6,
					nav:false
				}
			}
        });
		
		/*Wow animation*/

         new WOW().init();
		
		/*Tooltip*/
		  
		  $('[data-toggle="popover"]').popover();
		  $('[data-toggle="tooltip"]').tooltip();
		  

		/*magnificPopup Start*/
		
		
		
		/*scrollTop*/
		
		$('.scrollup').on('click',function(){
			$("html, body").animate({ scrollTop: 0 }, 600);
			return false;
		});
		
		/*On scroll*/
		
		$(window).on('scroll',function() {
		  if ($(this).scrollTop() > 0){  
			  $('header.for-sticky').addClass("sticky");
		     } else {
			  $('header.for-sticky').removeClass("sticky");
		   }
		   
		   if ($(this).scrollTop() > 300) {
				$('.scrollup').fadeIn();
			} else {
				$('.scrollup').fadeOut();
			}
		   
		});
		
		
		/*Counter*/
		
		$('.counter').each(function() {
		  var $this = $(this),
			  countTo = $this.attr('data-count');
		  
		  $({ countNum: $this.text()}).animate({
			countNum: countTo
		  },
		
		  {
		
			duration: 8000,
			easing:'linear',
			step: function() {
			  $this.text(Math.floor(this.countNum));
			},
			complete: function() {
			  $this.text(this.countNum);
			}
		
		  });  
		  
		}); 
		
		
		/*Date & Time Picker*/
		$('.datetimepicker1').datetimepicker(
		  {
			useCurrent: false,
			showTodayButton: true,
			showClear: true,
			showClose: true,
			inline: false,
			dayViewHeaderFormat: 'MMMM YYYY',
			collapse: true,
			icons: {
			  time: 'fa fa-clock',
			  date: 'fa fa-calendar',
			  today: 'fa fa-crosshairs',
			  clear: 'fa fa-trash-o',
			} 
		 });
		 
		 /*Youtube video background*/
		 $('[data-youtube]').youtube_background();
		 

    });

    jQuery(window).on('load',function(){
		
		
        jQuery(".wshipping-site-preloader-wrapper").fadeOut(300);
		
		/*Gallery Filter*/
		
		 // filter Gallery
		  $('.grid').isotope({
			  itemSelector: '.filtr-item',
		  });
	
		  $('.simplefilter').on( 'click', 'li', function() {
			var filterValue = $(this).attr('data-filter');
			$('.grid').isotope({ filter: filterValue });
			$('.simplefilter li').removeClass('active');
			$(this).addClass('active');
		  });
		
    });
	
}(jQuery));	