Prerequisites -

1. .NET SDK (8.0 or compatible)
2. Node.js (v18+ recommended)
3. npm (comes with Node.js)

Running the Backend Tests

From project root: dotnet test api.Tests/api.Tests.csproj

Expected output:

- All tests should pass (failed: 0, succeeded: 4)

Running the Backend (API)

1. Navigate to api folder: cd api
2. run it : dotnet run
3. Api will start locally on http://localhost:5111/
4. test out in swagger: http://localhost:5111/swagger/index.html

Running the Frontend (UI)

1. Open a new terminal and navigate to the UI folder: cd ui
2. install node modules : npm ci
3. start dev server : npm start
4. open http://localhost:3000 in browser

API Endpoint

POST /api/commision/calculate

Input: { localSalesCount, foreignSalesCount, averageSaleAmount }
Output: { avalphaCommissionAmount, competitorCommissionAmount }

Example:

- Local Sales: 5, Foreign Sales: 3, Average: £1000
- Result: Avalpha £2050, Competitor £326.50
