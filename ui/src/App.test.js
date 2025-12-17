import { render, screen, waitFor } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import App from "./App";
import * as commissionApi from "./services/commissionApi";

jest.mock("./services/commissionApi");

test("makes api request with form data", async () => {
  commissionApi.calculateCommission.mockResolvedValue({
    avalphaTechnologiesCommissionAmount: 100,
    competitorCommissionAmount: 50,
  });

  render(<App />);

  const inputs = screen.getAllByRole("textbox");
  await userEvent.type(inputs[0], "10");
  await userEvent.type(inputs[1], "5");
  await userEvent.type(inputs[2], "1000");
  await userEvent.click(screen.getByRole("button"));

  await waitFor(() => {
    expect(commissionApi.calculateCommission).toHaveBeenCalledWith({
      localSalesCount: 10,
      foreignSalesCount: 5,
      averageSaleAmount: 1000,
    });
  });
});
