let cpus = [];
let connection = null;

actorIdToUpdate = -1;

getdata();
setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:23793/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CpuCreated", (user, message) => {
        getdata();
    });

    connection.on("CpuDeleted", (user, message) => {
        getdata();
    });
    connection.on("CpuUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();
}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
async function getdata() {
    await fetch('http://localhost:23793/cpu')
        .then(x => x.json())
        .then(y => {
            cpus = y;
            console.log(cpus);
            display();
        });
}


function display() {
    document.getElementById('resultarea').innerHTML = "";
    cpus.forEach(t => {
        console.log(t.cpuName);
        document.getElementById('resultarea').innerHTML += "<tr><td>" + t.id + "</td><td>" + t.cpuName +
            "</td><td>" +
            `<button type="button" onclick="remove(${t.id})">Delete</button>` +
            `<button type="button" onclick="showupdate(${t.id})">Update</button>`
            + "</td></tr>";
    });
}
function showupdate(id) {
    document.getElementById('cpuupdate').value = cpus.find(x => x['id'] == id)['cpuName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    actorIdToUpdate = id;
}
    function update() {
        let name = document.getElementById('cpuupdate').value;
        fetch('http://localhost:23793/cpu/', {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                { id: actorIdToUpdate, cpuName: name }),
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
        document.getElementById('updateformdiv').style.display = 'none';
    }
    function remove(id) {
        fetch('http://localhost:23793/cpu/' + id, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json',
            },
            body: null
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => {
                console.error('Error:', error);
            });
    }
    function create() {
        let name = document.getElementById('cpu').value;
        fetch('http://localhost:23793/cpu', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(
                { cpuName: name }),
        })
            .then(response => response)
            .then(data => {
                console.log('Success:', data);
                getdata();
            })
            .catch((error) => {
                console.error('Error:', error);
            });

    }
