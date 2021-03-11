/*
 Template Name: Admiria - Bootstrap 4 Admin Dashboard
 Author: Themesbrand
 File: Dashboard Init
*/


!function($) {
    "use strict";

    var Dashboard = function() {};

    Dashboard.prototype.init = function () {

        // Peity line
        $('.peity-line').each(function() {
            $(this).peity("line", $(this).data());
        });

        //Knob chart
        $(".knob").knob();

        //C3 combined chart
        c3.generate({
            bindto: '#combine-chart',
            data: {
                columns: [
                    ['Qualified', @Html.Raw(Model.Tot)],
                    ['Followup', 330],
                    ['Presentation', 300],
                    ['ContractSent', 200],
                    ['Negotiation', 130],
                ],
                type: 'bar',
                colors: {
                    Qualified: '#5468da',
                    Followup: '#4ac18e',
                    Presentation: '#ffbb44',
                    ContractSent: '#ea553d',
                    Negotiation: '#6d60b0'
                },
                groups: [

                ]
            },
            axis: {
                x: {
                    type: 'categorized'
                }
            }
        });

        //C3 Donut Chart
        c3.generate({
            bindto: '#donut-chart',
            data: {
                columns: [
                    ['Qualified', @Html.Raw(Model.TotalStageQualified)],
                    ['Followup', 3],
                    ['Presentation', 2],
                    ['ContractSent', 3],
                    ['Negotiation', 1],
                    
                ],
                type : 'donut'
            },
            donut: {
                title: "Active Stages",
                width: 30,
                label: {
                    show:false
                }
            },
            color: {
                pattern: ["#5468da", "#4ac18e","#ffbb44", "#ea553d", "#6d60b0"]
            }
        });

    },
        $.Dashboard = new Dashboard, $.Dashboard.Constructor = Dashboard

}(window.jQuery),

//initializing
    function($) {
        "use strict";
        $.Dashboard.init()
    }(window.jQuery);