def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]

def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")
