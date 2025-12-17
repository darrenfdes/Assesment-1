import { post } from "../utils/httpClient";

export function calculateCommission(request) {
  return post("/commision", request);
}
