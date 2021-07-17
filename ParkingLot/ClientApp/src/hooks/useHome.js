import React, { useState, useEffect } from "react";
import API from "../services/API";



export const useReportGet = () => {

  const initialState = {
    listPaid: [{}],
    listUnpaid: [{}],
  };

  const [report, setReport] = useState(initialState);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(false);

  const getReport = async () => {
    try {
      setError(false);
      setLoading(true);
      const response = await API.getReport();
      //console.log(response);
      setReport(response);
    } catch (error) {
      setError(true);
    }
    setLoading(false);
  };

  useEffect(() => {
    getReport();
  }, []);

  return {
    report,
    loading,
    error,
  };
};


