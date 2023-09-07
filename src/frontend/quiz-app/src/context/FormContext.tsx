import React, { createContext, useContext, useEffect } from 'react';

import type { ReactNode, Dispatch } from 'react';

type Value = [any, Dispatch<React.SetStateAction<any>>, (route: string) => void];

const FormContext = createContext<Value>([null, () => {}, () => {}]);

interface FormProviderProps {
  children: ReactNode;
  value: Value;
}

function FormProvider({ children, value }: FormProviderProps) {
  return <FormContext.Provider value={value}>{children}</FormContext.Provider>;
}

function useSetForm(form: any) {
  const [, setFormInstance] = useContext(FormContext);
  useEffect(() => {
    setFormInstance(form);

    return () => setFormInstance(null);
  }, [form, setFormInstance]);
}

export { FormContext, FormProvider, useSetForm };  export type { FormProviderProps };

