<template>
    <div>
      <h1 class="display-4 text-center">Employee List</h1>
      <hr />
      <div class="row">
        <div class="col-lg-8 offset-lg-2">
          <div class="card mt-4">
            <div class="card-body">
              <div class="input-group">
                <input
                  type="text"
                  v-model="employeeName"
                  class="form-control form-control-lg"
                  placeholder="Add Employee"
                />
                <div class="input-group-append">
                  <button
                    v-on:click="addEmployee()"
                    class="btn btn-success btn-lg"
                  >
                    Add
                  </button>
                </div>
              </div>
              <br />
              <div class="text-center">
                <div
                  v-if="loading"
                  class="spinner-border text-success"
                  role="status"
                >
                  <span class="sr-only">Loading...</span>
                </div>
              </div>
  
              <h5 v-if="employees.length === 0">No employees are registered</h5>
              <ul v-if="!loading" class="list-group">
                <li
                  v-for="(employee, index) of employees"
                  :key="index"
                  class="list-group-item d-flex justify-content-between"
                >
                  {{ employee.name }}
                  <span
                    class="text-danger cursor"
                    v-on:click="deleteEmployee(employee.id)"
                  >
                    <i class="fas fa-trash-alt"></i>
                  </span>
                </li>
              </ul>
            </div>
          </div>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: "EmployeeList",
    data() {
      return {
        employeeName: "",
        employees: [],
        loading: false,
      };
    },
   
  };
  </script>
  
  <style scoped>
  .cursor {
    cursor: pointer;
  }
  </style>
  