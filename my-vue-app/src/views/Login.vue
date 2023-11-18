<template>
    <div>
      <input type="email" v-model="email" placeholder="Email" />
      <input type="password" v-model="password" placeholder="Password" />
      <button @click="login">Login</button>
    </div>
  </template>
  
  <script>
  import axios from 'axios'; // Import axios
  export default {
    name:"LoginPage",
    data() {
      return {
        email: "",
        password: "",
        error: null, // You should declare error in data to avoid undefined errors
      };
    },
    methods: {
      login() {
        // Make a POST request to your authentication endpoint
        axios
          .post("https://api.example.com/login", {
            email: this.email, // Fix: Use this.email instead of this.username
            password: this.password,
          })
          .then((response) => {
            // Assuming your backend returns a token upon successful login
            const token = response.data.token;
  
            // Store the token in local storage or Vuex store for future requests
            localStorage.setItem("token", token);
  
            // Redirect the user or perform other actions as needed
            // For example, you can use Vue Router to navigate to another page
            this.$router.push("/dashboard");
          })
          .catch((error) => {
            // Handle login errors
            this.error = "Invalid credentials. Please try again.";
            console.error("Login error:", error);
          });
      },
    },
  };
  </script>
  