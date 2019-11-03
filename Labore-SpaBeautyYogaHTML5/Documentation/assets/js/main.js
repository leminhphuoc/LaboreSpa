
(function($) {
    'use strict';

    $(document).ready(function() { 
        hunFunctions.ready();
    });

    var hunFunctions = {

        ready: function() {
            this.preLoading();
            this.menuFade();
        },

        /**
         * preLoading
         */
        preLoading: function() {
            try {
                $('.animsition').each(function() {
                    var dataLoader = $(this).data('loader');

                    $(this).animsition({
                        inClass: 'fade-in',
                        outClass: 'fade-out',
                        inDuration: 1500,
                        outDuration: 800,
                        linkElement: '.animsition-link',
                        loading: true,
                        loadingParentElement: 'html',
                        loadingClass: 'hun-pre-loading',
                        loadingInner: '<div class="' + dataLoader + '"></div>',
                        timeout: false,
                        timeoutCountdown: 5000,
                        onLoadEvent: true,
                        browser: [ 'animation-duration', '-webkit-animation-duration'],
                        overlay : false,
                        overlayClass : 'animsition-overlay-slide',
                        overlayParentElement : 'html',
                        transition: function(url){ window.location.href = url; }
                    });
                })
            } catch(er) {console.log(er);}
        },

        /**
         * menuFade
         */
        menuFade: function() {
            try {
                $('.item-menu-fade').on('click', function(event){
                    event.preventDefault();

                    $('.item-menu-fade').removeClass('active');
                    $(this).addClass('active');

                    $('.hun-content-site').fadeTo( 0, 0 );
                    $('html, body').animate({scrollTop: $($(this).attr('href')).offset().top}, 0);
                    $('.hun-content-site').fadeTo( 300, 1 );
                });             
            } catch(er) {console.log(er);} 


            try {
                var elemenOnePage = $('.section-content');
                var linkMenuOnePage = $('.item-menu-fade');

                $(window).on('scroll',function(){
                    linkMenuOnePage.removeClass('active'); 

                    for(var i = elemenOnePage.length - 1; i>=0; i--) { 
                        if($(window).scrollTop() + $(window).height() === $(document).height()) {
                            $( '.item-menu-fade[href="#'+ $(elemenOnePage[elemenOnePage.length - 1]).attr('id') +'"]').addClass('active');
                            break;
                        }
                        else if($(this).scrollTop() >= $(elemenOnePage[i]).offset().top - 60) { 
                            $( '.item-menu-fade[href="#'+ $(elemenOnePage[i]).attr('id') +'"]').addClass('active');
                            break;
                        }
                    }
                });

            } catch(er) {console.log(er);} 
        }
    };

})(jQuery);