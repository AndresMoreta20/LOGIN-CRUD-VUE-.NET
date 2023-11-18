<template>
    <div>
      <input type="email" v-model="email" placeholder="Email" />
      <input type="password" v-model="password" placeholder="Password" />
      <button @click="register">Register</button>
      <p v-if="error">{{ error }}</p>
    </div>
  </template>
  
  <script>
  import axios from 'axios';
  
  export default {
    name: "RegisterPage",
    data() {
      return {
        email: "",
        password: "",
        error: null,
      };
    },
    methods: {
      register() {
        // Make a POST request to your registration endpoint
        axios
          .post("https://localhost:7139/User/register", {
            userName: "string", // Replace with actual data or remove if not needed
            email: this.email,
            password: this.password,
          })
          .then((response) => {
            // Assuming your backend returns a token upon successful registration
            const token = response.data.token;
  
            // Store the token in local storage or Vuex store for future requests
            localStorage.setItem("token", token);
  
            // Redirect the user or perform other actions as needed
            // For example, you can use Vue Router to navigate to another page
            this.$router.push("/dashboard");
          })
          .catch((error) => {
            // Handle registration errors
            this.error = "Registration failed. Please try again.";
            console.error("Registration error:", error);
          });
      },
    },
  };
  </script>
  