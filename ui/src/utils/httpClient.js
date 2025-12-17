const BASE_URL =
  process.env.REACT_APP_API_BASE_URL || "http://localhost:5111/api";

export async function post(endpoint, body) {
  const response = await fetch(`${BASE_URL}${endpoint}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(body),
  });

  if (!response.ok) {
    let errorMessage = "Request failed";
    try {
      const error = await response.json();
      errorMessage = error?.message ?? errorMessage;
    } catch (error) {
      console.error("post: ", error);
    }
    throw new Error(errorMessage);
  }

  return response.json();
}
