<template>
  <router-view/>
</template>

<script>
export default {
  name: "app",
  beforeMount: function() {
    if (this.getCookie("Token") != "") {
      this.$store.commit("INSERIRTOKEN", this.getCookie("Token"));
      this.$store.commit("INSERIRTIPOUSER", this.getCookie("TipoUser"));
      this.$store.commit("CARREGARTOKEN");
      console.log(this.getCookie("Token"));
    } else {

      var local = this.$route.path;

      if (local != "/" && local != "/Login" && local != "/EsqueciMinhaSenha") {
        this.$router.push("/Login");
      }
        
    }
  },
  methods: {
    getCookie(cname) {
      var name = cname + "=";
      var decodedCookie = decodeURIComponent(document.cookie);
      var ca = decodedCookie.split(";");
      for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == " ") {
          c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
          return c.substring(name.length, c.length);
        }
      }
      return "";
    }
  }
};
</script>


