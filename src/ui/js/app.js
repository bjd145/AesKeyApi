const server_url = "http://bjdweb003.azurewebsites.net";

Vue.component('key-item', {
  props: ['k', 'index'],
  template:'\
  <span>\
        <h6 class="list-group-item-heading">Host: {{k.Host }}</h6>\
        <p class="list-group-item-text" v-if="k.Time">Time Generated: {{ k.Time }}</p>\
        <p class="list-group-item-text" v-if="k.AesKey">Key: {{ k.AesKey }}</p>\
  </span>',
  methods: {}
});

var app = new Vue({
  el: '#keys',

  data: {
    k: { Time: '', Host: '', Number: '', AesKey: '', NumberOfKeys: '' },
    keys: []  
  },
  delimiters: ['${', '}'],
  
  mounted: function () {
    this.fetchKey();
  },

  methods: {
    fetchKey: function () {
      var keys = [];
      this.$http.get("http://server_url/api/keys")
        .then(response => response.json())
        .then(result => {
          Vue.set(this.$data, 'keys', result);
          console.log("success in getting keys")  
        })
        .catch(err => {
            console.log(err);
        });
    },

    fetchKeys: function () {
      var keys = [];
      if (this.k.NumberOfKeys.trim()) {
        this.$http.post("http://$server_url/api/keys", { "NumberOfKeys": parseInt(this.k.NumberOfKeys.trim(), 10) } )
          .then(response => response.json())
          .then(result => {
            Vue.set(this.$data, 'keys', result);
            console.log("success in getting keys")  
          })
          .catch(err => {
            console.log(err);
         });
      }
    }
  }
});
