# Employee API

A .NET 8 Web API project for managing employees. It supports basic CRUD operations and is designed to run on Kubernetes with SQL Server as the backend.

---

##  Project Structure

```
EmployeeApi/
├── Controllers/
│   └── EmployeesController.cs
├── Data/
│   └── EmployeeContext.cs
├── Models/
│   └── Employee.cs
├── Properties/
│   └── launchSettings.json
├── appsettings.json
├── Dockerfile
├── EmployeeApi.http
├── Program.cs
└── README.md
```
employee-k8s-yamls folder is not part of this project. It is just kept here to keep everything in one place for review.
---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/)
- [kubectl](https://kubernetes.io/docs/tasks/tools/)
- Access to a Kubernetes cluster (e.g., GKE)

---

## Running Locally

```bash
dotnet build
dotnet run
```

> Once running, access:  
> `http://localhost:80/api/employees`

You can test endpoints using:
- `curl`
- `Postman`
- Built-in Swagger (if added)
- `EmployeeApi.http` file (Visual Studio)

---

## Docker Build & Push

```bash
docker build -t teambufftronics/employeeapi .
docker push teambufftronics/employeeapi
```
https://hub.docker.com/r/teambufftronics/employeeapi -- I have put this image on a public repository
---

## Kubernetes Deployment

```bash
kubectl apply -f employee-k8s-yamls/
```
> employee-k8s-yamls has all yamls in a sequential order.
> After applying, access this service via the external IP of the Ingress:  
> `http://<INGRESS_IP>/api/employees`

---

## Environment Variables for DB Connection

Used in `Program.cs` for dynamic DB configuration:

- `DB_SERVER`
- `DB_NAME`
- `DB_USER`
- `DB_PASS`

These are injected in the Kubernetes deployment YAML.

---

## API Endpoints

| Method | Endpoint              | Description               |
|--------|-----------------------|---------------------------|
| GET    | /api/employees        | Get all employees         |
| GET    | /api/employees/{id}   | Get employee by ID        |
| POST   | /api/employees        | Create a new employee     |
| PUT    | /api/employees/{id}   | Update an employee        |
| DELETE | /api/employees/{id}   | Delete an employee        |

---

## Live Demo (if deployed)

- **API URL:** `http://<ingress-ip>/api/employees`
- **SwaggerPI URL:** `http:///<ingress-ip>/swagger/index.html`
- **Docker Hub:** [`teambufftronics/employeeapi`](https://hub.docker.com/r/teambufftronics/employeeapi)

---

## Author

**Aayush Dayal**
