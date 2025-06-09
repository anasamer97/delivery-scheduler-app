# 🚚 Delivery Scheduler App

This is a fullstack project that allows users to schedule delivery slots based on product types with custom business rules. It includes a .NET 7 Web API backend and a React + TypeScript + Tailwind frontend.

---

## 🧩 Tech Stack

- **Frontend:** React, TypeScript, TailwindCSS (Vite)
- **Backend:** ASP.NET Core Web API (.NET 7)

---

## 📁 Project Structure

```
delivery-scheduler-app/
├── frontend/       # React frontend
└── backend/        # .NET backend (DeliveryApi)
```

---

## 🚀 How to Run the Project Locally

### 1. Clone the Repo

```bash
git clone https://github.com/anasamer97/delivery-scheduler-app.git
cd delivery-scheduler-app
```

---

### 2. Run the Backend (.NET)

```bash
cd backend/DeliveryApi
dotnet restore
dotnet run
```

You should see something like:
```
Now listening on: https://localhost:7023
```

Keep note of this port — you'll use it in the frontend `.env`.

---

### 3. Run the Frontend (React)

```bash
cd ../../frontend
cp .env.example .env

Edit the .env file and match the port from the backend output: VITE_API_BASE_URL=https://localhost:7023/api/delivery <--  Copy the port number from the backend and paste it here
```env
VITE_API_BASE_URL=https://localhost:7023/api/delivery
```

npm install
npm run dev
```

📍 Frontend runs at: `http://localhost:5173`

---

## 🧪 Features

- ✅ Add products dynamically (InStock, FreshFood, External)
- ✅ View available delivery dates with business rules:
  - **InStock:** same day before 6 PM, otherwise next day
  - **FreshFood:** same day before 12 PM, otherwise next day
  - **External:** from 3 days later, only Tuesday–Friday
- ✅ Time slots are shown from 8 AM to 10 PM
- ✅ Green slots (preferred): 1–3 PM and 8–10 PM
- ✅ Fully dynamic UI — no need to write JSON manually
- ✅ Click any date to see matching time slots

---


```
📅 Product selection -> Delivery date options -> Time slot view
```

---

