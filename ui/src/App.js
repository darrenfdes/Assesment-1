import logo from "./logo.png";
import "./App.css";
import { calculateCommission } from "./services/commissionApi";
import { formatCurrency } from "./utils/formatter";
import { useState } from "react";

function App() {
  const [formData, setFormData] = useState({
    localSalesCount: "",
    foreignSalesCount: "",
    averageSaleAmount: "",
  });

  const [results, setResults] = useState({
    avalphaTechnologiesCommission: 0,
    competitorCommission: 0,
  });

  const [isLoading, setIsLoading] = useState(false);

  const [errorMessage, setErrorMessage] = useState(null);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prev) => ({
      ...prev,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setIsLoading(true);
    setErrorMessage(null);

    try {
      const result = await calculateCommission({
        localSalesCount: Number(formData.localSalesCount),
        foreignSalesCount: Number(formData.foreignSalesCount),
        averageSaleAmount: Number(formData.averageSaleAmount),
      });

      setResults({
        avalphaTechnologiesCommission:
          result.avalphaTechnologiesCommissionAmount,
        competitorCommission: result.competitorCommissionAmount,
      });
    } catch (error) {
      setResults({
        avalphaTechnologiesCommission: 0,
        competitorCommission: 0,
      });

      setErrorMessage(error.message);
    } finally {
      setIsLoading(false);
    }
  };

  return (
    <div className="App">
      <header className="App-header">
        <div className="logo-container">
          <img
            src={logo}
            className="App-logo"
            alt="Avalpha Technologies Logo"
          />
          <h1 className="company-title">Avalpha Technologies</h1>
          <h2 className="app-subtitle">Commission Calculator</h2>
        </div>
      </header>
      <main className="main-content">
        {errorMessage && <div className="error-message">{errorMessage}</div>}

        <div className="calculator-container">
          <div className="form-section">
            <h3>Sales Information</h3>
            <form onSubmit={handleSubmit} className="calculator-form">
              <div className="form-group">
                <label htmlFor="localSalesCount">Local Sales Count</label>
                <input
                  type="number"
                  id="localSalesCount"
                  name="localSalesCount"
                  value={formData.localSalesCount}
                  onChange={handleInputChange}
                  placeholder="Enter number of local sales"
                  required
                />
              </div>

              <div className="form-group">
                <label htmlFor="foreignSalesCount">Foreign Sales Count</label>
                <input
                  type="number"
                  id="foreignSalesCount"
                  name="foreignSalesCount"
                  value={formData.foreignSalesCount}
                  onChange={handleInputChange}
                  placeholder="Enter number of foreign sales"
                  required
                />
              </div>

              <div className="form-group">
                <label htmlFor="averageSaleAmount">
                  Average Sale Amount (£)
                </label>
                <input
                  type="number"
                  step="0.01"
                  id="averageSaleAmount"
                  name="averageSaleAmount"
                  value={formData.averageSaleAmount}
                  onChange={handleInputChange}
                  placeholder="Enter average sale amount"
                  required
                />
              </div>

              <button
                type="submit"
                className={`calculate-btn ${isLoading ? "loading" : ""}`}
                disabled={isLoading}
              >
                {isLoading ? "Calculating..." : "Calculate Commission"}
              </button>
            </form>
          </div>

          <div className="results-section">
            <h3>Commission Results</h3>
            <div className="results-grid">
              <div className="result-card avalpha-card">
                <div className="result-header">
                  <h4>Avalpha Technologies</h4>
                  <span className="commission-rates">
                    Local: 20% | Foreign: 35%
                  </span>
                </div>
                <div className="result-amount">
                  {formatCurrency(results.avalphaTechnologiesCommission)}
                </div>
              </div>

              <div className="result-card competitor-card">
                <div className="result-header">
                  <h4>Competitor</h4>
                  <span className="commission-rates">
                    Local: 2% | Foreign: 7.55%
                  </span>
                </div>
                <div className="result-amount">
                  {formatCurrency(results.competitorCommission)}
                </div>
              </div>
            </div>

            {results.avalphaTechnologiesCommission > 0 && (
              <div className="advantage-indicator">
                <p className="advantage-text">
                  Avalpha Technologies advantage:
                  <strong>
                    {formatCurrency(
                      results.avalphaTechnologiesCommission -
                        results.competitorCommission
                    )}
                  </strong>
                </p>
              </div>
            )}
          </div>
        </div>
      </main>

      <footer className="App-footer">
        <p>&copy; 2025 Avalpha Technologies. All rights reserved.</p>
      </footer>
    </div>
  );
}

export default App;
