var options = {
    series: [{
    data: [400, 430, 448, 470, 540],
    name: "Product",
  }],
    chart: {
    type: 'bar',
    background: "transparent",
    height: 350
  },
  plotOptions: {
    bar: {
      borderRadius: 4,
      horizontal: false,
      distributed: true,
      columnwidth: "40%",
    }
  },
  dataLabels: {
    enabled: false
  },
  xaxis: {
    categories: ['Jordan1', 'Yeezy', 'New Balance', 'FearOfGod', 'Nike'],
    labels:{
        offsetY: 5,
        style: {
            colors: "#f5f7ff"
        },
    },
  }, 
  yaxis:{
    labels: {
        style:{
            colors: ["#f5f7ff"]
        },
      },
    },

  
  };

  var chart = new ApexCharts(document.querySelector("#bar-chart"), options);
  chart.render();





  /*------------Area-------------*/

  var options = {
    series: [{
    name: 'Purchase Orders',
    type: 'area',
    data: [44, 55, 31, 47, 31, 43]
  }, {
    name: 'Sales Orders',
    type: 'line',
    data: [11, 32, 45, 32, 34, 41]
  }],
    chart: {
    height: 350,
    type: 'line',
  },
  stroke: {
    curve: 'smooth'
  },
  fill: {
    type:'solid',
    opacity: [0.35, 1],
  },
  colors: ["#00ab57","#d50000"],
  labels: ['Jan', 'Feb','Mar','Apr','May','Jun','Jul'],
  markers: {
    size: 0
  },
  xaxis:{
    labels:{
        offsetY: 5,
        style: {
            colors: "#f5f7ff"
        },
    },
  },
  yaxis: [
    {
      title: {
        text: 'Purchase Orders',
        style:{
            color: "#f5f7ff"
        },
      },
      labels: {
        style:{
            colors: ["#f5f7ff"]
        },
      },
    },
    {
      opposite: true,
      title: {
        text: 'Sales Orders',
        style:{
            color: "#f5f7ff"
        },
      },
      labels: {
        style:{
            colors: ["#f5f7ff"]
        },
      },
    },
  ],
  tooltip: {
    shared: true,
    intersect: false,
    y: {
      formatter: function (y) {
        if(typeof y !== "undefined") {
          return  y.toFixed(0) + " points";
        }
        return y;
      }
    }
  }
  };

  var chart = new ApexCharts(document.querySelector("#area-chart"), options);
  chart.render();