const uri = 'api/Employees'; // Updated API endpoint
let employees = [];

function getItems() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('Unable to get employees.', error));
}

function addItem() {
    const addNameTextbox = document.getElementById('add-name');

    const employee = {
        name: addNameTextbox.value.trim()
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    })
        .then(response => response.json())
        .then(() => {
            getItems();
            addNameTextbox.value = '';
        })
        .catch(error => console.error('Unable to add employee.', error));
}

function deleteItem(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to delete employee.', error));
}

function displayEditForm(id) {
    const employee = employees.find(employee => employee.id === id);

    document.getElementById('edit-name').value = employee.name;
    document.getElementById('edit-id').value = employee.id;
    document.getElementById('editForm').style.display = 'block';
}

function updateItem() {
    const employeeId = document.getElementById('edit-id').value;
    const employee = {
        id: parseInt(employeeId, 10),
        name: document.getElementById('edit-name').value.trim()
    };

    fetch(`${uri}/${employeeId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(employee)
    })
        .then(() => getItems())
        .catch(error => console.error('Unable to update employee.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}

function _displayItems(data) {
    const tBody = document.getElementById('employees');
    tBody.innerHTML = '';

    data.forEach(employee => {
        let editButton = document.createElement('button');
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${employee.id})`);

        let deleteButton = document.createElement('button');
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteItem(${employee.id})`);

        let tr = tBody.insertRow();

        let td1 = tr.insertCell(0);
        td1.appendChild(document.createTextNode(employee.id));

        let td2 = tr.insertCell(1);
        td2.appendChild(document.createTextNode(employee.name));

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    employees = data;
}

// Initial call to get employees when the page loads
getItems();
