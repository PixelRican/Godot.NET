from re import Match, sub

def camel(symbol: str) -> str:
    return symbol[0].lower() + pascal(symbol)[1:]

def pascal(symbol: str) -> str:
    return symbol.title().replace("_", "")

def preprocess(symbol: str) -> str:
    def substitute(match: Match) -> str:
        group: str = match.group()
        match group:
            case "ptrcall":
                return "ptr_call"
            case "userdata":
                return "user_data"
            case "refcount":
                return "ref_count"
            case "classdb":
                return "class_d_b"
            case "classname":
                return "class_name"
            case "methodname":
                return "method_name"
            case _:
                return group

    return sub(r"[a-z]+", substitute, symbol)
